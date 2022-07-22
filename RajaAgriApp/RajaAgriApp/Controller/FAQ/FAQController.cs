using RajaAgriApp.Models;
using RajaAgriApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RajaAgriApp.Controller
{

    public  class FAQController: IFAQController
    {
        private IFAQService _fAQService;
        private IFAQCategoryService _fAQCategoryService;

        public FAQController(IFAQService FAQService, IFAQCategoryService FAQCategoryService)
        {
            _fAQService=FAQService;
            _fAQCategoryService=FAQCategoryService;
        }

        public Task<FAQResponseModel> GetFAQ(int FAQCategoryId)
        {
            var response=_fAQService.GetFAQ(FAQCategoryId);
            return response;
        }

        public Task<FAQCategoryResponseModel> GetFAQCategory()
        {
            var response = _fAQCategoryService.GetFAQCategory();
            return response;
        }
    }
}
