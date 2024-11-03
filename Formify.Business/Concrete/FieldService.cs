using AutoMapper;
using Formify.Business.Abstract;
using Formify.Business.Dtos.FieldDtos;
using Formify.DataAccess.Repositories.Abstract;
using Formify.Domain.Entities;

namespace Formify.Business.Concrete
{
    public class FieldService : IFieldService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FieldService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<FieldDto> GetFieldByIdAsync(int id)
        {
            var field = await _unitOfWork.Fields.GetByIdAsync(id);
            return _mapper.Map<FieldDto>(field);
        }

        public async Task<IEnumerable<FieldDto>> GetFieldsByFormIdAsync(int formId)
        {
            var fields = await _unitOfWork.Fields.FindAsync(f => f.FormId == formId);
            return _mapper.Map<IEnumerable<FieldDto>>(fields);
        }

        public async Task AddFieldAsync(CreateFieldDto fieldDto)
        {
            var field = _mapper.Map<Field>(fieldDto);
            await _unitOfWork.Fields.AddAsync(field);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateFieldAsync(FieldDto fieldDto)
        {
            var field = _mapper.Map<Field>(fieldDto);
            _unitOfWork.Fields.Update(field);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteFieldAsync(int id)
        {
            var field = await _unitOfWork.Fields.GetByIdAsync(id);
            if (field != null)
            {
                _unitOfWork.Fields.Remove(field);
                await _unitOfWork.CompleteAsync();
            }
        }
    }
}