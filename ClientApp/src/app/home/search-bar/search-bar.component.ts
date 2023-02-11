import { Component, EventEmitter, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-search-bar',
  templateUrl: './search-bar.component.html',
  styleUrls: ['./search-bar.component.css'],
})
export class SearchBarComponent implements OnInit {
  search: string = '';
  @Output() searchInput = new EventEmitter<string>();

  constructor() {}

  ngOnInit(): void {}

  emitSearch() {
    this.searchInput.emit(this.search);
  }
}
