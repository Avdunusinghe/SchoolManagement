import { CheckBoxModel } from './../common/check-box-model';
import { Injectable } from '@angular/core';

@Injectable()
export class SubjectModel{
    id:number;
    name:string;
    subjectCode:string;
    subjectCategory:number;
    categorysId:number;
    subjectCategoryName:string;
    subjectType:number;
    parentBasketSubjectId:number;
    parentBasketSubjectName:string;
    subjectStreamId:number;
    subjectStreamName:string;
    isActive:boolean;
    createdByName:string;
    createdOn:Date;
    updatedOn:Date;
    updatedByName:string;
    subjectAcademicLevels:CheckBoxModel[];
}