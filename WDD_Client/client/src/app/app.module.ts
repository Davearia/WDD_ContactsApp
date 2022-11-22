import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from "@angular/common/http";
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { PhoneBook } from './services/phoneBook.service';
import ContactsListView from './views/contactsListView.component';

@NgModule({
  declarations: [
        AppComponent,
        ContactsListView,   
  ],
  imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule
  ],
    providers: [
        PhoneBook
    ],
  bootstrap: [AppComponent]
})
export class AppModule { }
