import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Student } from '../Models/Student';
import { DatePipe } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-detailed',
  templateUrl: './detailed.component.html',
  styleUrl: './detailed.component.css'
})
export class DetailedComponent {
  @Input() selectedStudent: Student | null = null;
  @Output() confirmDelete = new EventEmitter<void>();
  studentToDelete: Student | null = null;
  showModal = false;
  constructor(private router: Router,private datePipe: DatePipe, private http: HttpClient) { }
  //editableStudent: Student = Student;

  getInitials(name: string) {
    return name.split(' ').map((n: string) => n[0]).join('');
  }
  getImgUrl() {
    return "https://localhost:7272/"+this.selectedStudent?.profileImage
  }
  getFormattedDate(date: string): string | null {
    return this.datePipe.transform(date, 'dd/MM/yyyy');
  }
  onDelete(student: any) {
    this.studentToDelete = student;
    this.showModal = true;
  }
  onConfirmDelete() {
    if (this.studentToDelete) {
      this.http.delete(`api/Students/${this.studentToDelete.id}`).subscribe(
        () => {
          this.confirmDelete.emit();
          this.selectedStudent=null
          this.showModal = false;
          this.studentToDelete = null;
        },
        error => {
          console.error('Error deleting item', error);
          this.showModal = false;
          this.studentToDelete = null;
        }
      );
    }
  }
  onCancelDelete() {
    this.showModal = false;
    this.studentToDelete = null;
  }
  navigateToUpdate(studentId: number): void {
    this.router.navigate([`/updatestudent`, studentId]);
  }
}
