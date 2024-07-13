import { Component, Input } from '@angular/core';
import { Student } from '../Models/Student';

@Component({
  selector: 'app-detailed',
  templateUrl: './detailed.component.html',
  styleUrl: './detailed.component.css'
})
export class DetailedComponent {
  @Input() selectedStudent: Student | null = null;
  //editableStudent: Student = Student;

  getInitials(name: string) {
    return name.split(' ').map((n: string) => n[0]).join('');
  }
}
