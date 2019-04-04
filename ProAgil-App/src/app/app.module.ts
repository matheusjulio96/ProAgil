import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { TooltipModule, BsDropdownModule, ModalModule, BsDatepickerModule } from 'ngx-bootstrap';

import { EventoService } from './_services/evento.service';

import { AppComponent } from './app.component';
import { EventosComponent } from './eventos/eventos.component';
import { NavComponent } from './nav/nav.component';

import { DateTimeFormatPipePipe } from './_helps/DateTimeFormatPipe.pipe';


@NgModule({
   declarations: [
      AppComponent,
      EventosComponent,
      NavComponent,
      DateTimeFormatPipePipe
   ],
   imports: [
      BrowserModule,
      AppRoutingModule,
      HttpClientModule,
      FormsModule,
      TooltipModule.forRoot(),
      BsDropdownModule.forRoot(),
      ModalModule.forRoot(),
      ReactiveFormsModule,
      BsDatepickerModule.forRoot(),
    ],
   providers: [
     EventoService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
