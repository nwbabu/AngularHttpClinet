import { Component, OnInit } from '@angular/core';
import {HttpClientModule, HttpClient, HttpErrorResponse} from '@angular/common/http';
import {ObservableServiceService} from '../observable-service.service';
import { NgProgress } from 'ngx-progressbar';

@Component({
  selector: 'app-user-info',
  templateUrl: './user-info.component.html',
  styleUrls: ['./user-info.component.css']
})
export class UserInfoComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

}
