using Core.Models;
using Domain;
using Infraestrutucture.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Feature
{
    public class SaborFeature
    {
        private SaborRepository _repository;

        public SaborFeature(SaborRepository repository)
        {
            _repository = repository;
        }


        public async Task<ApiResponse<Sabor>> BuscarPorId(Guid id)
        {
            try
            {
                var data = await _repository.BuscarPorId(id);
                return new ApiResponse<Sabor>(Domain.TableStatic.StatusCodes.Status200OK, data);
            }
            catch (Exception ex)
            {
               return new ApiResponse<Sabor>(Domain.TableStatic.StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        public async Task<ApiResponse<IEnumerable<Sabor>>> GetItems()
        {
            try
            {
                var data = await _repository.BuscarItems();
                return new ApiResponse<IEnumerable<Sabor>>(Domain.TableStatic.StatusCodes.Status200OK, data);

            }
            catch (Exception ex)
            {
                return new ApiResponse<IEnumerable<Sabor>>(Domain.TableStatic.StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        public async Task<ApiResponse<Sabor>> Adicionar(Sabor data)
        {
            try
            {
                await _repository.Adicionar(data);
                return new ApiResponse<Sabor>(Domain.TableStatic.StatusCodes.Status200OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Sabor>(Domain.TableStatic.StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        public async Task<ApiResponse<Sabor>> Remover(Guid id)
        {
            try
            {
                var model = await _repository.BuscarPorId(id);
                await _repository.Remover(model);
                return new ApiResponse<Sabor>(Domain.TableStatic.StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Sabor>(Domain.TableStatic.StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
