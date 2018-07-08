import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserModule } from '../../node_modules/@angular/platform-browser';
import { AppComponent } from '../app/app.component';

@NgModule({
    declarations: [AppComponent],
    imports: [ CommonModule, BrowserModule ],
    exports: [],
    providers: [],
    bootstrap: [AppComponent],
})
export class AppModule {}
