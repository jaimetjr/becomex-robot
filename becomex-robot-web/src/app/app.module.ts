import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component'
import { ArmComponent } from './components/arm.component/arm.component';
import { HeadComponent } from './components/head.component/head.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    ArmComponent,
    HeadComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
