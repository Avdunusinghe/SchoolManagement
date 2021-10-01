﻿using SchoolManagement.ViewModel;
using SchoolManagement.ViewModel.Common;
using SchoolManagement.ViewModel.Lesson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Business.Interfaces.LessonData
{
    public interface IEssayQuestionAnswerService
    {
        Task<ResponseViewModel> SaveEssayQuestionAnswer(EssayQuestionAnswerViewModel vm, string userName);

        List<EssayQuestionAnswerViewModel> GetAllEssayQuestionAnswers();

        List<DropDownViewModel> GetAllQuestions();

        Task<ResponseViewModel> DeleteEssayAnswer(int id);

        PaginatedItemsViewModel<BasicEssayQuestionAnswerViewModel> GetQuestionList(string searchText, int currentPage, int pageSize, int questionId);
    }
}
