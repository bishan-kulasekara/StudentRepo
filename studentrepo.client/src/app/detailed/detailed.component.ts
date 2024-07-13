import { Component, Input, OnChanges, SimpleChanges } from '@angular/core';
import { Student } from '../Models/Student';

@Component({
  selector: 'app-detailed',
  templateUrl: './detailed.component.html',
  styleUrls: ['./detailed.component.css']
})
export class DetailedComponent implements OnChanges {
  @Input() selectedStudent: Student = Student.getInstance();
  editMode: boolean = false;

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['selectedStudent']) {
      const currentValue = changes['selectedStudent'].currentValue;
      const previousValue = changes['selectedStudent'].previousValue;
      console.log('User changed from', previousValue, 'to', currentValue);
    }
    //if (changes.['selectedStudent'].) {
      // Set edit mode based on whether the selected student is new or existing
    //  this.editMode = this.selectedStudent.id === -1;
    //}
  }

  getInitials(name: string): string {
    return name.split(' ').map((n: string) => n[0]).join('');
  }
}
