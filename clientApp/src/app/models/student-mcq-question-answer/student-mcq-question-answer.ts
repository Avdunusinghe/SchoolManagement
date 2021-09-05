import { Injectable } from '@angular/core';

@Injectable()
export class StudentMcqQuestionAnswerModel {
    questionId : number;
    questionName : string;
    studentId : number;
    studentName : string;
    teacherComments : string;
    marks : number;
    isCorrectAnswer : boolean;
}


        