﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Business.Interfaces.MasterData;
using SchoolManagement.ViewModel;
using SchoolManagement.ViewModel.Master;
using SchoolManagement.ViewModel.Master.Academic;
using SchoolManagement.WebService.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeadOfDepartmentController : ControllerBase
    {
        private readonly IHeadOfDepartmentService HeadOfDepartmentService;
        private readonly IIdentityService identityService;

        public HeadOfDepartmentController(IHeadOfDepartmentService HeadOfDepartmentService, IIdentityService identityService)
        {
            this.HeadOfDepartmentService = HeadOfDepartmentService;
            this.identityService = identityService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var response = HeadOfDepartmentService.GetAllHeadOfDepartment();
            return Ok(response);
        }

        [HttpPost]
        [Route("saveHeadOfDepartment")]
        public async Task<ActionResult> Post([FromBody] HeadOfDepartmentViewModel vm)
        {
            var userName = identityService.GetUserName();
            var response = await HeadOfDepartmentService.SaveHeadOfDepartment(vm, userName);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var response = await HeadOfDepartmentService.DeleteHeadOfDepartment(id);
            return Ok(response);
        }

        [HttpGet]
        [Route("getAllAcademicYears")]
        public ActionResult GetAllAcademicYears()
        {
            var response = HeadOfDepartmentService.GetAllAcademicYears();

            return Ok(response);
        }

        [HttpGet]
        [Route("getAllAcademicLevels")]
        public ActionResult GetAllAcademicLevels()
        {
            var response = HeadOfDepartmentService.GetAllAcademicLevels();

            return Ok(response);
        }

        [HttpGet]
        [Route("getAllTeachers")]
        public ActionResult GetAllTeachers()
        {
            var response = HeadOfDepartmentService.GetAllTeachers();

            return Ok(response);
        }

        [HttpGet]
        [Route("getAllSubjects")]
        public ActionResult GetAllSubjects()
        {
            var response = HeadOfDepartmentService.GetAllSubjects();

            return Ok(response);
        }

        
        [HttpGet]
        [Route("getHeadOfDepartmentList")]
        public PaginatedItemsViewModel<BasicHeadOfDepartmentViewModel> GetHeadOfDepartmentList(string searchText, int currentPage, int pageSize)
        {
            var response = HeadOfDepartmentService.GetHeadOfDepartmentList(searchText, currentPage, pageSize);

            return response;
        }

        [HttpGet]
        [RequestSizeLimit(long.MaxValue)]
        [Route("downloadheadOfDepartmentList")]
        public FileStreamResult downloadUserListReport()
        {
            var response = HeadOfDepartmentService.downloadHeadOfDepartmentListReport();

            return File(new MemoryStream(response.FileData), "application/pdf", response.FileName);
        }


    }
}
