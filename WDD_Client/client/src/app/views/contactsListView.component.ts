import { Component, OnInit } from "@angular/core";
import { NgForm } from '@angular/forms';
import { PhoneBook } from "../services/phoneBook.service";
import { Contacts } from "../shared/contacts";
import { Hero } from './hero';

@Component({
	selector: "contacts-list",
	templateUrl: "contactsListView.component.html"
})	

export default class ContactsListView implements OnInit {
	
	existingContacts = "Existing Contacts"	
	newContact = "New Contact"	
	public contact = new Contacts(-1, "", "", "");	
	
	constructor(public phoneBook: PhoneBook) {
		
	}
		    
    ngOnInit(): void {
		this.phoneBook.loadContacts()
			.subscribe();    
	}

	saveContact(contact: Contacts): void {	
		console.log(contact.id);
		if (contact.id > -1) {
			this.phoneBook.updateContact(contact);
			var existingContact = this.phoneBook.contacts.find(c => c.id == contact.id);

			if (existingContact != null) {
				existingContact.firstName = contact.firstName;
				existingContact.lastName = contact.lastName;
				existingContact.phoneNumber = contact.phoneNumber;
			}
		}
		else {
			this.phoneBook.createContact(contact);
		}
		
		this.clearContactForm();
	}

	updateContact(contact: Contacts): void {	
		this.contact.id = contact.id;
		this.contact.firstName = contact.firstName;
		this.contact.lastName = contact.lastName;
		this.contact.phoneNumber = contact.phoneNumber
	}

	clearContactForm(): void {
		this.contact = new Contacts(-1, "", "", "");	
	}
	
}