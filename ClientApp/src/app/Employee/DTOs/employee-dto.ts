export interface EmployeeDto {
  id: number;
  firstName: string | null;
  lastName: string | null;
  email: string | null;
  age: number;
  doj: string | null;
  gender: string | null;
  isMarried: number;
  isActive: number;
  designationId: number;
  designation: string | null;
  name: string | null;
}