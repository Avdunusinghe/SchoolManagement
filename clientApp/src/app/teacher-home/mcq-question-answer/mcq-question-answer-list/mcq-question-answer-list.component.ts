import { McqQuestionAnswerService } from './../../../services/mcq-question-answer/mcq-question-answer.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { DatatableComponent } from '@swimlane/ngx-datatable';
import { ToastrService } from 'ngx-toastr';
import { Component, OnInit, ViewChild } from '@angular/core';

@Component({
  selector: 'app-mcq-question-answer-list',
  templateUrl: './mcq-question-answer-list.component.html',
  styleUrls: ['./mcq-question-answer-list.component.sass'],
  providers: [ToastrService],
})

export class McqQuestionAnswerListComponent implements OnInit {

  @ViewChild(DatatableComponent, { static: false }) table: 
    DatatableComponent;
    data = [];
    scrollBarHorizontal = window.innerWidth < 1200;
    loadingIndicator = false;
    reorderable = true;
    McqQuestionAnswerForm: FormGroup;


  constructor(
    private fb: FormBuilder,
    private modalService: NgbModal,
    private McqQuestionAnswerService : McqQuestionAnswerService,
    private toastr: ToastrService
  ) { }

  ngOnInit(): void {
    this.getAll();
  }

  //add new question using form
  createNewMcqQuestionAnswer(content)
  {
    this.McqQuestionAnswerForm = this.fb.group({
      questionid:['', [Validators.required]],
      answertext:['', [Validators.required]],
      modifieddate:['', [Validators.required]],
      createdon:['', [Validators.required]],
    });

    this.modalService.open(content, {
      ariaLabelledBy: 'modal-basic-title',
      size: 'lg',
    });
  }

  getAll() {}



  //save MCQ Student Answer button 
  saveMcqStudentAnswer()
  {
    console.log(this.McqQuestionAnswerForm.value);

    this.McqQuestionAnswerService.saveMcqQuestionAnswer(this.McqQuestionAnswerForm.value)
      .subscribe(response=>{
        
        if(response.isSuccess)
        {
            this.modalService.dismissAll();
            this.toastr.success(response.message,"Success");
            //this.getAll();
        }
        else
        {
            this.toastr.error(response.message,"Error");
        }
      },error=>{

            this.toastr.error("Network error has been occre.Please try again","Error");
      });

    }
    
}