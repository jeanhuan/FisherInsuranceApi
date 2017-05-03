import {Component} from '@angular/core';
import { AuthService } from '../../auth.service';

@Component({
    selector: 'quotes-home-page',
    templateurl: './app/components/quotes/quotes.component.html'
})

export class QuotesComponent {
    constructor( private authService: AuthService ){}
}