using AutoMapper;
using Formify.Business.Abstract;
using Formify.Business.Dtos.FormDtos;
using Formify.DataAccess.Repositories.Abstract;
using Formify.Domain.Entities;

namespace Formify.Business.Concrete
{
    public class FormService : IFormService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FormService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<FormDto> GetFormByIdAsync(int id)
        {
            var form = await _unitOfWork.Forms.GetFormWithFieldsAsync(id);
            return _mapper.Map<FormDto>(form);
        }

        public async Task<IEnumerable<FormDto>> GetAllFormsAsync()
        {
            var forms = await _unitOfWork.Forms.GetAllAsync();
            return _mapper.Map<IEnumerable<FormDto>>(forms);
        }

        public async Task AddFormAsync(CreateFormDto createFormDto)
        {
            var form = _mapper.Map<Form>(createFormDto);
            await _unitOfWork.Forms.AddAsync(form);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateFormAsync(FormDto formDto)
        {
            var form = _mapper.Map<Form>(formDto);
            _unitOfWork.Forms.Update(form);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteFormAsync(int id)
        {
            var form = await _unitOfWork.Forms.GetByIdAsync(id);
            if (form != null)
            {
                _unitOfWork.Forms.Remove(form);
                await _unitOfWork.CompleteAsync();
            }
        }
    }
}