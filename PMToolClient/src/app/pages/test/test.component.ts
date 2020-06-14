import { Component, OnInit } from '@angular/core';
import { TestService } from 'src/app/services/test.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.scss']
})
export class TestComponent implements OnInit {

  message: string;

  constructor(private testService: TestService) { }

  async ngOnInit() {
    this.message = await (await this.testService.testMe()).message;
  }

}
