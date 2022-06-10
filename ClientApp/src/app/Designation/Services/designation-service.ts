import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { DesignationDto } from '../DTOs/designation-dto';

@Injectable({
  providedIn: 'root'
})
export class DesignationService {

  constructor(private myhttp: HttpClient) { }
  designationUrl: string = "https://localhost:7013/api/Designation";
  designationList: DesignationDto[] = [] as DesignationDto[];
  designation: DesignationDto = {} as DesignationDto;
  insertDesignation() {
    return this.myhttp.post(`${this.designationUrl}/${this.designation.id}`, this.designation);
  }
  updateDesignation() {
    return this.myhttp.put(`${this.designationUrl}/${this.designation.id}`, this.designation);
  }
  deleteDesignation(id: number) {
    return this.myhttp.delete(`${this.designationUrl}/${this.designation.id}`);
  }
  getDesignation(): Observable<DesignationDto[]> {
    return this.myhttp.get<DesignationDto[]>(this.designationUrl);
  }
}
