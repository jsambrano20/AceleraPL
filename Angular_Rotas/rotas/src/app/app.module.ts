import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './page/home/home.component';
import { MenuComponent } from './_shared/Layout/menu/menu.component';
import { SobreComponent } from './page/sobre/sobre.component';
import { ContatoComponent } from './page/contato/contato.component';
import { ErrorComponent } from './page/error/error.component';

@NgModule({
  declarations: [AppComponent, HomeComponent, MenuComponent, SobreComponent, ContatoComponent, ErrorComponent],
  imports: [BrowserModule, AppRoutingModule, ReactiveFormsModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
