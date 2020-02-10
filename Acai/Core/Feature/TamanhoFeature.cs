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
    public class TamanhoFeature
    {
        private TamanhoRepository _repository;

        public TamanhoFeature(TamanhoRepository repository)
        {
            _repository = repository;
        }


        public async Task<ApiResponse<Tamanho>> BuscarPorId(Guid id)
        {
            try
            {
                var data = await _repository.BuscarPorId(id);
                return new ApiResponse<Tamanho>(Domain.TableStatic.StatusCodes.Status200OK, data);
            }
            catch (Exception ex)
            {
               return new ApiResponse<Tamanho>(Domain.TableStatic.StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        public async Task<ApiResponse<IEnumerable<Tamanho>>> GetItems()
        {
            try
            {
                var data = await _repository.BuscarItems();
                return new ApiResponse<IEnumerable<Tamanho>>(Domain.TableStatic.StatusCodes.Status200OK, data);

            }
            catch (Exception ex)
            {
                return new ApiResponse<IEnumerable<Tamanho>>(Domain.TableStatic.StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        public async Task<ApiResponse<Tamanho>> Adicionar(Tamanho data)
        {
            try
            {
                await _repository.Adicionar(data);
                return new ApiResponse<Tamanho>(Domain.TableStatic.StatusCodes.Status200OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Tamanho>(Domain.TableStatic.StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        public async Task<ApiResponse<Tamanho>> Remover(Guid id)
        {
            try
            {
                var model = await _repository.BuscarPorId(id);
                await _repository.Remover(model);
                return new ApiResponse<Tamanho>(Domain.TableStatic.StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Tamanho>(Domain.TableStatic.StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
