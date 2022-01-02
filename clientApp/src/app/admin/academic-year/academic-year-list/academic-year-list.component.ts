import { MessageService } from 'primeng/api';
import { AcademicYearModel } from './../../../models/academic-Year/academic.Year.model';
import { DropDownModel } from './../../../models/common/drop-down.model';
import { AcademicYearService } from './../../../services/academic-Year/academic-Year.service';
import { DatatableComponent } from '@swimlane/ngx-datatable';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Component, OnInit, ViewChild } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-academic-year-list',
  templateUrl: './academic-year-list.component.html',
  styleUrls: ['./academic-year-list.component.scss'],
  providers: [MessageService]
})
export class AcademicYearListComponent implements OnInit {

  @ViewChild(DatatableComponent, { static: false }) table: DatatableComponent;
  data = [];
  scrollBarHorizontal = window.innerWidth < 1200;
  loadingIndicator = false;
  academicYearFrom:FormGroup;
  reorderable = true;
  academicYear:AcademicYearModel;
  
  
  constructor(
    private fb: FormBuilder,
    private modalService: NgbModal,
    private academicYearService:AcademicYearService,
    private messageService: MessageService) { }

  ngOnInit(): void {

    this.getAll();
    
  }
  
  getAll()
  {
    this.loadingIndicator=true;
    this.academicYearService.getAll().subscribe(response=>
    {
        this.data= response;
        this.loadingIndicator=false;
    },error=>{
      this.loadingIndicator=false;
      this.messageService.add({severity:'error', summary: 'Error', detail: 'Network error has been occured. Please try again.'});
    });
  }


  addNewAcademicYear(content) {
    

    this.academicYearFrom = this.fb.group({
      id: [null, [Validators.required]],
      isActive:[true]
     
    });

    this.modalService.open(content, {
      ariaLabelledBy: 'modal-basic-title',
      size: 'lg',
    });
  }

  //Save Academic Year

  saveAcademicYear(){   
    
    console.log(this.academicYearFrom.value);
    
    this.academicYearService.saveAcademicYear(this.academicYearFrom.value).subscribe(response=>{

        if(response.isSuccess)
        {
          this.modalService.dismissAll();
          this.messageService.add({severity:'success', summary: 'Success', detail: response.message});
          this.getAll();
        }
        else
        {
          this.messageService.add({severity:'error', summary: 'error', detail: response.message});
        }

    },error=>{
      this.messageService.add({severity:'error', summary: 'Error', detail: 'Network error has been occured. Please try again.'});
    });

  }
  

    onAddRowSave(form: FormGroup) {
      this.data.push(form.value);
      this.data = [...this.data];
      form.reset();
      this.modalService.dismissAll();
     
    }


  editRow(row:AcademicYearModel, rowIndex:number, content:any) {

    console.log(row);

    this.academicYearFrom = this.fb.group({
      
      isActive: [row.isActive, [Validators.required]],
    });

    this.modalService.open(content, {
      ariaLabelledBy: 'modal-basic-title',
      size: 'lg',
    });
    
  }


  // delete Academic Year

  deleteAcademicYear(row) {
    Swal.fire({
      title: 'Are you sure Delete Academic Year ?',
      showCancelButton: true,
      confirmButtonColor: 'red',
      cancelButtonColor: 'green',
      confirmButtonText: 'Yes',
    }).then((result) => {

      if (result.value) {

        this.academicYearService.delete(row.id).subscribe(response=>{

          if(response.isSuccess)
          {
            this.messageService.add({severity:'success', summary: 'Success', detail: response.message});
            this.getAll();
          }
          else
          {
            this.messageService.add({severity:'error', summary: 'error', detail: response.message});
          }
    
        },error=>{
          this.messageService.add({severity:'error', summary: 'Error', detail: 'Network error has been occured. Please try again.'});
        });
      }
    });
  }

}
