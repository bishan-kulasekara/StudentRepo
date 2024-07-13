import { Component } from '@angular/core';
import { Student } from '../Models/Student';

@Component({
  selector: 'app-newstudent',
  templateUrl: './newstudent.component.html',
  styleUrl: './newstudent.component.css'
})
export class NewstudentComponent {
  newStudent: Student = Student.getInstance();

}
