import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { Student } from '../Models/Student';

@Component({
  selector: 'app-updatestudent',
  templateUrl: './updatestudent.component.html',
  styleUrls: ['./updatestudent.component.css']
})
export class UpdatestudentComponent implements OnInit {
  student = {
    id: '',
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

  constructor(private route: ActivatedRoute, private http: HttpClient, private router: Router) { }

  ngOnInit(): void {
    const studentId = this.route.snapshot.paramMap.get('id');
    if (studentId) {
      this.getStudentDetails(studentId);
    }
  }

  getStudentDetails(id: string): void {
    this.http.get(`api/Students/${id}`).subscribe(
      (response: any) => {
        this.student = response;
        this.student.dateOfBirth = this.formatDateForInput(response.dateOfBirth);
        if (this.student.profileImage) {
          this.imageUrl = `https://localhost:7272/${this.student.profileImage}`;
        }
        console.log(this.student.dateOfBirth)
      },
      (error: any) => {
        this.errorMessage = 'An error occurred while fetching student details.';
      }
    );
  }

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
    formData.append('id', this.student.id);
    formData.append('firstName', this.student.firstName);
    formData.append('lastName', this.student.lastName);
    formData.append('mobile', this.student.mobile);
    formData.append('email', this.student.email);
    formData.append('nic', this.student.nic);
    formData.append('dateOfBirth', this.student.dateOfBirth);
    formData.append('address', this.student.address);
    if (this.selectedFile) {
      formData.append('file', this.selectedFile);
    }

    this.http.put(`api/Students/${this.student.id}`, formData).subscribe(
      (response: any) => {
        this.router.navigate(['/Repository']); // Redirect to the main page
        this.errorMessage = ''; // Clear error message on success
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

  goBack(): void {
    this.router.navigate(['/Repository']);
  }
  formatDateForInput(dateString: string): string {
    const date = new Date(dateString);
    const year = date.getFullYear();
    const month = (date.getMonth() + 1).toString().padStart(2, '0');
    const day = date.getDate().toString().padStart(2, '0');
    return `${year}-${month}-${day}`;
  }

}
