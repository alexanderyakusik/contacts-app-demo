import { Component, OnInit } from '@angular/core';
import { Contact } from '../contact.interface';
import { ContactsService } from '../contacts.service';

@Component({
  selector: 'app-contacts-grid',
  templateUrl: './contacts-grid.component.html',
  styles: [
  ]
})
export class ContactsGridComponent implements OnInit {

  public contacts: Contact[] = [];

  constructor(
    private service: ContactsService,
  ) {}

  ngOnInit(): void {
    this.service.getAll()
      .subscribe(contacts => this.contacts = contacts);
  }

}
