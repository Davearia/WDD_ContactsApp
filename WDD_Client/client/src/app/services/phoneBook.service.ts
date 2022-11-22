import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { first, map, Observable } from "rxjs";
import { Contacts } from "../shared/contacts";

@Injectable()
export class PhoneBook {

	constructor(private http: HttpClient) {

	}

	public contacts: Contacts[] = [];

	apiRoot: string = "https://localhost:7024/api/Contacts/";

	loadContacts(): Observable<void> {
		return this.http.get<Contacts[]>(this.apiRoot)
			.pipe(map(data => {
				this.contacts = data;
				return
			}));
	}

	createContact(contact: Contacts) {			
		this.http.post<Contacts>(this.apiRoot, contact)
			.subscribe();

		this.contacts.push(contact);
	}

	updateContact(contact: Contacts) {			
		this.http.put<Contacts>(this.apiRoot + contact.id, contact)
			.subscribe();
	}

	deleteContact(id: number) {	
		if (confirm("Are you sure you want to delete the contact?")) {
			this.http.delete(this.apiRoot + id)
				.subscribe()

			this.contacts = this.contacts.filter(c => c.id != id);
		}							
	}
	
}
