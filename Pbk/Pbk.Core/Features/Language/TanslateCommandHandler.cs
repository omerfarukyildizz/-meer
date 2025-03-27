using Pbk.Core.Behaviors;
using Pbk.Entities.Models;
using Pbk.Entities.Repositories;
using System.Threading;


namespace Pbk.Core.Features.User
{
    public class TanslateCommandHandler: ITranslate
    {
        ITranslateRepository _translateRepository;
        ILanguageRepository _languageRepository;
        IUnitOfWork _unitOfWork;
        public TanslateCommandHandler(ITranslateRepository tranlateRepository, ILanguageRepository languageRepository, IUnitOfWork unitOfWork)
        {
            _translateRepository = tranlateRepository;
            _languageRepository = languageRepository;
            _unitOfWork = unitOfWork;
        }

        public string createKey(string key)
        {
            return null;
        }

        public async Task<bool> Add(string TranslateKey)
        {
            try
            {
                var list = _languageRepository.GetAll();

                foreach (var item in list)
                {
                    Translate trans = new Translate();

                    trans.ServiceId = AppHelper.ServiceId;
                    trans.LanguageId = item.LanguageId;
                    trans.TranslateKey = TranslateKey;
                    trans.TranslateValue = TranslateKey;
                    trans.IsActive = true;
                    trans.InsUserId = AppHelper.ServiceId;
                    trans.InsDate = DateTime.Now;

                    await _translateRepository.AddAsync(trans);
                    await _unitOfWork.SaveChangesAsync();
                  
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public async Task<string> GetTranslation(string request)
        {
            try
            {
                var translate = _translateRepository.GetWhere(w => w.TranslateKey == request && w.LanguageId == AppHelper.LanguageId).FirstOrDefault();
                if (translate == null)
                {
                   await Add(request); return request;
                }
                else
                {
                    return translate.TranslateValue;
                }
            }
            catch (Exception ex)
            {
                return request;
            }

        }
 

    }
}
