import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { EmployeeDto } from '../DTOs/employee-dto';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  constructor(private myhttp: HttpClient) { }
  employeeUrl: string = "https://localhost:7013/api/Employee";
  employeesList: EmployeeDto[] = [] as EmployeeDto[];
  employee: EmployeeDto = {} as EmployeeDto;

  insertEmployee() {
    return this.myhttp.post(this.employeeUrl, this.employee);
  }

  updateEmployee() {
    return this.myhttp.put(`${this.employeeUrl}/${this.employee.id}`, this.employee);
  }
  deleteEmployee(id: number) {
    return this.myhttp.delete(`${this.employeeUrl}/${id}`);
  }
  getEmployees(): Observable<EmployeeDto[]> {
    return this.myhttp.get<EmployeeDto[]>(this.employeeUrl);
  }
}
