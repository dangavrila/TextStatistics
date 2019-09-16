import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { MenuLinkItem } from '@app/models';
import { Router } from '@angular/router';
import { AuthService } from '@app/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class AppHeaderComponent implements OnInit {

  @Input()
  links: Array<MenuLinkItem>;

  constructor(private router: Router, public service: AuthService) { }

  ngOnInit() {
  }

  logout() {
    this.service.logout();
    this.router.navigateByUrl('login');
  }

}
