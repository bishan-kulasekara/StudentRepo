import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { DetailedComponent } from './detailed/detailed.component';
import { FormsModule } from '@angular/forms';
import { NewstudentComponent } from './newstudent/newstudent.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    DetailedComponent,
    NewstudentComponent
  ],
  imports: [
    BrowserModule, HttpClientModule,FormsModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
