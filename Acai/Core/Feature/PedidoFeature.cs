using Core.Models;
using Domain;
using Infraestrutucture.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Feature
{
    public class PedidoFeature
    {
        private PedidoRepository _repository;
        private AdicionalRepository _repositoryAdicional;
        private SaborRepository _repositorySabor;
        private TamanhoRepository _repositoryTamanho;

        public PedidoFeature(PedidoRepository repository,
            AdicionalRepository adicionalRepository,
            SaborRepository saborRepository,
            TamanhoRepository tamanhoRepository)
        {
            _repository = repository;
            _repositoryAdicional = adicionalRepository;
            _repositorySabor = saborRepository;
            _repositoryTamanho = tamanhoRepository;
        }


        public async Task<ApiResponse<Pedido>> BuscarPorId(Guid id)
        {
            try
            {
                var data = await _repository.BuscarPorId(id);
                return new ApiResponse<Pedido>(Domain.TableStatic.StatusCodes.Status200OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Pedido>(Domain.TableStatic.StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        public async Task<ApiResponse<IEnumerable<Pedido>>> GetItems()
        {
            try
            {
                var data = await _repository.BuscarItems();
                return new ApiResponse<IEnumerable<Pedido>>(Domain.TableStatic.StatusCodes.Status200OK, data);

            }
            catch (Exception ex)
            {
                return new ApiResponse<IEnumerable<Pedido>>(Domain.TableStatic.StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        public async Task<ApiResponse<PedidoProcesadoModel>> Adicionar(PedidoModel data)
        {
            try
            {
                var model = new Domain.Pedido
                {
                    IdSabor = data.IdSabor,
                    IdTamanho = data.IdTamanho,
                };

                string NomesAdicionais = "";
                if (data.Adicionais.Count > 0)
                {
                    var adicionais = await _repositoryAdicional.GetItems(f => data.Adicionais.Contains(f.Id));
                    model.TempoTotal = adicionais.Sum(f => f.MinutosAdicionais);
                    model.ValorTotal = adicionais.Sum(f => f.ValorAdicionais);
                    NomesAdicionais = string.Join(',', adicionais.Select(f => f.Nome).ToArray());
                }

                var sabor = await _repositorySabor.BuscarPorId(data.IdSabor);
                model.TempoTotal += sabor.MinutosAdicionais;

                var tamanho = await _repositoryTamanho.BuscarPorId(data.IdTamanho);
                model.TempoTotal += tamanho.MinutosAdicionais;
                model.ValorTotal += tamanho.Valor;

                foreach (var item in data.Adicionais)
                {
                    var itemAdicional = new PedidoAdicional() { IdAdicional = item, Pedido = model };
                    _repository.Context.Entry<PedidoAdicional>(itemAdicional).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                    model.PedidoAdicionais.Add(itemAdicional);
                }

                await _repository.Adicionar(model);

                var pediProcessado = new PedidoProcesadoModel()
                {
                    Sabor = model.Sabor.Nome,
                    Tamanho = model.Tamanho.Nome,
                    TempoTotal = model.TempoTotal,
                    ValorTotal = model.ValorTotal,
                    Personalizacoes = NomesAdicionais
                };

                return new ApiResponse<PedidoProcesadoModel>(Domain.TableStatic.StatusCodes.Status200OK, pediProcessado);
            }
            catch (Exception ex)
            {
                return new ApiResponse<PedidoProcesadoModel>(Domain.TableStatic.StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        public async Task<ApiResponse<Pedido>> Remover(Guid id)
        {
            try
            {
                var model = await _repository.BuscarPorId(id);
                await _repository.Remover(model);
                return new ApiResponse<Pedido>(Domain.TableStatic.StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Pedido>(Domain.TableStatic.StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
