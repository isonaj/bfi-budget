import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AccordionModule, CollapseModule } from 'ngx-bootstrap';
import { DragDropModule } from '@angular/cdk/drag-drop';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    AccordionModule.forRoot(),
    CollapseModule.forRoot(),
    DragDropModule
  ],
  exports: [
    AccordionModule,
    CollapseModule,
    DragDropModule
  ]
})
export class SharedModule { }
