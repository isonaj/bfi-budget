import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { transferArrayItem, moveItemInArray, CdkDragDrop, CdkDragStart } from '@angular/cdk/drag-drop';

@Component({
  selector: 'app-transactions',
  templateUrl: './transactions.component.html',
  styleUrls: ['./transactions.component.scss']
})
export class TransactionsComponent implements OnInit {
  transactions: any;
  categories = [
    { name: 'Category 1', txns:[] },
    { name: 'Category 2', txns:[] },
    { name: 'Category 3', txns:[] },
    { name: 'Category 4', txns:[] },
    { name: 'Category 5', txns:[] },
  ];
  dragging: boolean;

  constructor(private client: HttpClient) { }

  ngOnInit() {
    this.client.get('/api/transactions').subscribe(data => {
      this.transactions = data;
    });
  }

  submit(e) {
    e.preventDefault();
    console.log('submit');
    this.client.post('/api/transactions/upload', null).subscribe(data => {
    });
  }

  select(e, idx) {
    this.transactions[idx].selected = !this.transactions[idx].selected;
  }
  
  public onDragStart(event: CdkDragStart<string[]>) {
    this.dragging = true;
  }

  drop(event: CdkDragDrop<string[]>) {
    const selections = [];

    // Get the indexes for all selected items
    for (var i = this.transactions.length; i >= 0; i--)
      if (this.transactions[i].selected) 
        selections.push(i);

    if (event.previousContainer === event.container) {
      moveItemInArray(event.container.data, event.previousIndex, event.currentIndex);
    } else {
      for (var i = this.transactions.length; i >= 0; i--) {
        if (this.transactions[i].selected) 
          transferArrayItem(event.previousContainer.data,
            event.container.data,
            i, //event.previousIndex,
            event.currentIndex);
        }
    }  
    this.dragging = false;
  }

  getTotal(cat) {
    return cat.txns.reduce((pv, cv) => pv + cv.amount, 0);
  }
}
