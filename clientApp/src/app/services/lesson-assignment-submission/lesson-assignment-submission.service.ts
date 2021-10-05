import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { DropDownModel } from 'src/app/models/common/drop-down.model';
import { ResponseModel } from 'src/app/models/common/response.model';
import {​​​​​​​​ environment }​​​​​​​​ from'../../../environments/environment';
import { LessonAssignmentSubmissionModel } from '../../models/lesson-assignment-submission/lesson.assignment.submission.model';
import {LessonAssignmentSubmissionPaginatedItemsViewModel} from '../../models/lesson-assignment-submission/lesson.assignment.submission.paginated.items'

@Injectable({
  providedIn: 'root'
})
export class LessonAssignmentSubmissionService {

  constructor(private httpClient: HttpClient) {​​​​​​​​ }​​​​​​​​
   
  getAll(): Observable <LessonAssignmentSubmissionModel[]>{​​​​​​​​
  return this.httpClient.
  get<LessonAssignmentSubmissionModel[]>(environment.apiUrl + 'LessonAssignmentSubmission')
    }​​​​​​​​
   
  saveLessonAssignmentSubmission(lessonassignmentsubmission: LessonAssignmentSubmissionModel): Observable<ResponseModel> {​​​​​​​​
  return this.httpClient.
  post<ResponseModel>(environment.apiUrl + 'LessonAssignmentSubmission/', lessonassignmentsubmission);
    }​​​​​​​​
  
    
  delete(Id: number): Observable<ResponseModel> { 
  return this.httpClient.
   delete<ResponseModel>(environment.apiUrl + 'LessonAssignmentSubmission' + Id); 
    }

  getAllStudents():Observable<DropDownModel[]>{
   return this.httpClient.
   get<DropDownModel[]>(environment.apiUrl + 'LessonAssignmentSubmission/getAllStudents');
      }

   getAllLessonAssignments():Observable<DropDownModel[]>{
    return this.httpClient.
    get<DropDownModel[]>(environment.apiUrl + 'LessonAssignmentSubmission/getAllLessonAssignments');
        }

   getLessonAssignmentsList(searchText: string, currentPage: number, pageSize: number, lessonassignmentId:number,):Observable<LessonAssignmentSubmissionPaginatedItemsViewModel>{
          return this.httpClient.get<LessonAssignmentSubmissionPaginatedItemsViewModel>(environment.apiUrl + "LessonAssignmentSubmission/getLessonAssignmentsList",{
            params:new HttpParams()
              .set('searchText',searchText)
              .set('currentPage', currentPage.toString())
              .set('pageSize', pageSize.toString())
              .set('lessonassignmentId', lessonassignmentId.toString())
      
          });
        }
}
