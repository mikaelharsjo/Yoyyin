using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yoyyin.Data;
using Yoyyin.Data.Core.Repositories;
using Yoyyin.Data.UnitOfWork;
using Yoyyin.Domain.QA;
using Yoyyin.Domain.Services;

namespace Yoyyin.Web.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public QuestionController(IQuestionRepository questionRepository, IUnitOfWork unitOfWork)
        {
            _questionRepository = questionRepository;
            _unitOfWork = unitOfWork;
        }

        public ActionResult Add(Question question)
        {
            _questionRepository.Add(question);
            _unitOfWork.Commit();

            return new EmptyResult();
        }


        public ActionResult Index()
        {
            return new EmptyResult();
        }
    }
}
