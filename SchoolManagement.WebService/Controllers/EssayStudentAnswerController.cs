﻿using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Business.Interfaces.LessonData;
using SchoolManagement.ViewModel;
using SchoolManagement.ViewModel.Lesson;
using SchoolManagement.WebService.Infrastructure.Services;
using System.Threading.Tasks;

namespace SchoolManagement.WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EssayStudentAnswerController : ControllerBase
    {
        private readonly IEssayStudentAnswerService essaystudentanswerService;
        private readonly IIdentityService identityService;

        public EssayStudentAnswerController(IEssayStudentAnswerService essaystudentanswerService, IIdentityService identityService)
        {
            this.essaystudentanswerService = essaystudentanswerService;
            this.identityService = identityService;
        }

        [HttpPost]

        public async Task<ActionResult> Post([FromBody] EssayStudentAnswerViewModel vm)
        {
            var userName = identityService.GetUserName();
            var response = await essaystudentanswerService.SaveEssayStudentAnswer(vm, userName);
            return Ok(response);
        }

        [HttpGet]

        public ActionResult GetAllEssayStudentAnswers()
        {
            var response = essaystudentanswerService.GetAllEssayStudentAnswers();
            return Ok(response);
        }


        [HttpGet]
        [Route("getAllQuestions")]
        public IActionResult GetAllQuestions()
        {
            var response = essaystudentanswerService.GetAllQuestions();

            return Ok(response);
        }

        [HttpGet]
        [Route("getAllStudents")]
        public IActionResult GetAllStudents()
        {
            var response = essaystudentanswerService.GetAllStudents();

            return Ok(response);
        }


        [HttpGet]
        [Route("getAllEssayQuestionAnswers")]
        public IActionResult GetAllEssayQuestionAnswers()
        {
            var response = essaystudentanswerService.GetAllEssayQuestionAnswers();

            return Ok(response);
        }

        [HttpGet]
        [Route("getStudentEssayList")]
        public PaginatedItemsViewModel<BasicEssayStudentAnswerViewModel> GetStudentEssayList(string searchText, int currentPage, int pageSize, int questionId, int studentId)
        {
            var response = essaystudentanswerService.GetStudentEssayList(searchText, currentPage, pageSize, questionId,studentId);

            return response;
        }
    }
}
