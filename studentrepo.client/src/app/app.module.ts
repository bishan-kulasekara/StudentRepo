import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { DetailedComponent } from './detailed/detailed.component';
import { FormsModule } from '@angular/forms';
import { NewstudentComponent } from './newstudent/newstudent.component';
import { DatePipe } from '@angular/common';
import { DeleteConfirmationModalComponent } from './delete-confirmation-modal/delete-confirmation-modal.component';
import { UpdatestudentComponent } from './updatestudent/updatestudent.component';
import { MainComponent } from './main/main.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    DetailedComponent,
    NewstudentComponent,
    DeleteConfirmationModalComponent,
    UpdatestudentComponent,
    MainComponent
  ],
  imports: [
    BrowserModule, HttpClientModule,FormsModule,
    AppRoutingModule
  ],
  providers: [
    DatePipe
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
