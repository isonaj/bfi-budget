import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AccordionModule, CollapseModule } from 'ngx-bootstrap';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    AccordionModule.forRoot(),
    CollapseModule.forRoot(),
  ],
  exports: [
    AccordionModule,
    CollapseModule
  ]
})
export class SharedModule { }
