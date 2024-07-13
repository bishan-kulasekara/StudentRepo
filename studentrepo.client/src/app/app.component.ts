import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

import { Student } from './Models/Student';
import { StudentSummaryDTO } from './Models/StudenSummaryDTO';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  public students: StudentSummaryDTO[] = [];
  public selectedStudent: Student|null =  null;
  searchQuery: string = '';
  sortColumn: string = 'FirstName';
  sortDirection: string = 'asc';

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getStudents();
  }

  getStudents() {
    let url = `https://localhost:7272/api/Students?searchQuery=${this.searchQuery}&sortBy=${this.sortColumn}&sortDirection=${this.sortDirection}`;
    this.http.get<StudentSummaryDTO[]>(url).subscribe(
      (result) => {
        this.students = result;
      },
      (error) => {
        console.error('Error occurred:', error);
        if (error.status === 200) {
          console.error('Unexpected response format, possibly HTML:', error.error.text);
        }
      }
    );
  }

  sort(column: string) {
    if (this.sortColumn === column) {
      this.sortDirection = this.sortDirection === 'asc' ? 'desc' : 'asc';
    } else {
      this.sortColumn = column;
      this.sortDirection = 'asc';
    }
    this.getStudents();
  }

  onSearch() {
    this.getStudents();
  }

  getStudentDetails(id: number) {
    if (this.selectedStudent && this.selectedStudent.id === id) {
      this.selectedStudent=null;
    } else {
      this.http.get<Student>(`https://localhost:7272/api/Students/${id}`).subscribe(
        (result) => {
          console.log(result); // Debugging line
          this.selectedStudent = result;
        },
        (error) => {
          console.error(error);
        }
      );
    }
  }

  title = 'studentrepo.client';
}
