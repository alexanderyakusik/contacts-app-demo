import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContactsGridComponent } from './contacts/contacts-grid/contacts-grid.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'contacts',
    pathMatch: 'full'
  },
  {
    path: 'contacts',
    children: [
      {
        path: '',
        component: ContactsGridComponent,
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
