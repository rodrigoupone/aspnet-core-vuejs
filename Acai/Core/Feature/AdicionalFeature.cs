using Core.Models;
using Domain;
using Infraestrutucture.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Feature
{
    public class AdicionalFeature
    {
        private AdicionalRepository _repository;

        public AdicionalFeature(AdicionalRepository repository)
        {
            _repository = repository;
        }


        public async Task<ApiResponse<Adicional>> BuscarPorId(Guid id)
        {
            try
            {
                var data = await _repository.BuscarPorId(id);
                return new ApiResponse<Adicional>(Domain.TableStatic.StatusCodes.Status200OK, data);
            }
            catch (Exception ex)
            {
               return new ApiResponse<Adicional>(Domain.TableStatic.StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        public async Task<ApiResponse<IEnumerable<Adicional>>> GetItems()
        {
            try
            {
                var data = await _repository.BuscarItems();
                return new ApiResponse<IEnumerable<Adicional>>(Domain.TableStatic.StatusCodes.Status200OK, data);

            }
            catch (Exception ex)
            {
                return new ApiResponse<IEnumerable<Adicional>>(Domain.TableStatic.StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        public async Task<ApiResponse<Adicional>> Adicionar(Adicional data)
        {
            try
            {
                await _repository.Adicionar(data);
                return new ApiResponse<Adicional>(Domain.TableStatic.StatusCodes.Status200OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Adicional>(Domain.TableStatic.StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        public async Task<ApiResponse<Adicional>> Remover(Guid id)
        {
            try
            {
                var model = await _repository.BuscarPorId(id);
                await _repository.Remover(model);
                return new ApiResponse<Adicional>(Domain.TableStatic.StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Adicional>(Domain.TableStatic.StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
