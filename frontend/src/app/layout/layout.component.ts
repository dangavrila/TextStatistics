import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.css']
})
export class AppLayoutComponent implements OnInit {

  constructor(private route: ActivatedRoute) {
    this.route.data.subscribe((data) => {
      this.pageName = data.pageName;
    });
   }

   pageName: string;

  ngOnInit() {
  }

}
