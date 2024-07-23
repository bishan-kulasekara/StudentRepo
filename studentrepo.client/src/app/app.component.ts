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
export class AppComponent  {


  title = 'studentrepo.client';
}
