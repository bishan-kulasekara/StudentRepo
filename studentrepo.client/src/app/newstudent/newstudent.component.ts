import { Component, EventEmitter, Output } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-newstudent',
  templateUrl: './newstudent.component.html',
  styleUrls: ['./newstudent.component.css']
})
export class NewstudentComponent {
  @Output() createdStudent = new EventEmitter<void>();
  student = {
    firstName: '',
    lastName: '',
    mobile: '',
    email: '',
    nic: '',
    dateOfBirth: '',
    address: '',
    profileImage: ''
  };
  selectedFile: File | null = null;
  imageUrl: string | null = null;
  errorMessage: string = '';

  constructor(private http: HttpClient) { }

  onFileSelected(event: any): void {
    const file = event.target.files[0];
    if (file && file.type.startsWith('image/')) {
      this.selectedFile = file;

      const reader = new FileReader();
      reader.onload = (e: any) => {
        this.imageUrl = e.target.result;
      };
      reader.readAsDataURL(file);
    } else {
      this.selectedFile = null;
      this.imageUrl = null;
    }
  }

  clearImage(event: any): void {
    event.stopPropagation();
    this.selectedFile = null;
    this.imageUrl = null;
  }

  onSubmit(): void {
    const formData: FormData = new FormData();
    formData.append('firstName', this.student.firstName);
    formData.append('lastName', this.student.lastName);
    formData.append('mobile', this.student.mobile);
    formData.append('email', this.student.email);
    formData.append('nic', this.student.nic);
    formData.append('dateOfBirth', this.student.dateOfBirth);
    formData.append('address', this.student.address);
    formData.append('profileImage', this.student.profileImage);
    if (this.selectedFile) {
      formData.append('file', this.selectedFile);
    }

    this.http.post('api/Students', formData).subscribe(
      (response: any) => {
        if (this.errorMessage === '') {
          this.resetForm();
        }
        this.errorMessage = ''; // Clear error message on success
        this.createdStudent.emit();
      },
      (error: any) => {
        if (error.status === 400 && error.error.errors) {
          const validationErrors = error.error.errors;
          this.errorMessage = 'Validation Errors:\n' + Object.keys(validationErrors).map(key => validationErrors[key].join('\n')).join('\n');
        } else {
          this.errorMessage = 'An unexpected error occurred.';
        }
      }
    );
  }
  resetForm(): void {
    this.student = {
      firstName: '',
      lastName: '',
      mobile: '',
      email: '',
      nic: '',
      dateOfBirth: '',
      address: '',
      profileImage: ''
    };
    this.selectedFile = null;
    this.imageUrl = null;
  }
}
