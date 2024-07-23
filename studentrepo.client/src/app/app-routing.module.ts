import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { UpdatestudentComponent } from './updatestudent/updatestudent.component';
import { MainComponent } from './main/main.component';

const routes: Routes = [
  { path: 'Repository', component: MainComponent },
  { path: 'updatestudent/:id', component: UpdatestudentComponent },
  { path: '', redirectTo: '/Repository', pathMatch: 'full' },
  { path: '**', redirectTo: '/Repository' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
