import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import type { Contact } from './contact.interface';
import { apiConfig } from '../api-config';

@Injectable()
export class ContactsService {

  constructor(
    private httpClient: HttpClient,
  ) { }

  public getAll(): Observable<Contact[]> {
    return this.httpClient.get<Contact[]>(apiConfig.baseUrl + '/api/contacts');
  }

}
