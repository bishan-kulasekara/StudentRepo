import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

import { Student } from './Models/Student';
import { StudentSummaryDTO } from './Models/StudenSummaryDTO';
import { PagedResult } from './Models/PagedResult';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  public students: StudentSummaryDTO[] = [];
  public selectedStudent: Student | null = null;

  searchQuery: string = '';
  sortColumn: string = 'FirstName';
  sortDirection: string = 'asc';
  pageNumber: number = 1;
  pageSize: number = 10;
  totalRecords: number = 0;
  pages: number = 1;

  pageslist = Array(1).fill(0);

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getStudents();
  }
  

  goToPage(page: number) {
    if (page < 1 || page > this.pages) {
      return; // Prevent navigation to invalid pages
    }
    this.pageNumber = page;
    this.getStudents();
  }
  getStudents() {
    let url = `https://localhost:7272/api/Students?searchQuery=${this.searchQuery}&sortBy=${this.sortColumn}&sortDirection=${this.sortDirection}&pageNumber=${this.pageNumber}&pageSize=${this.pageSize}`;
    this.http.get<PagedResult<StudentSummaryDTO>>(url).subscribe(
      (result) => {
        this.students = result.data;
        this.totalRecords = result.totalRecords;
        this.pages = Math.ceil(this.totalRecords / this.pageSize);
        this.pageslist = Array(this.pages).fill(0)
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
    this.pageNumber = 1;
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
