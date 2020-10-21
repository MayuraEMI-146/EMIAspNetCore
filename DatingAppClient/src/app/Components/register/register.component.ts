
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from 'src/app/Services/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent implements OnInit {
  @Output() public cancelRegister = new EventEmitter();
public model: any = {};
  constructor(private accountService: AccountService, private toastrService: ToastrService) { }

  public ngOnInit(): void {
  }

  public register() {
    console.log(this.model);
    this.accountService.register(this.model).subscribe((response) => {
      console.log(response);
      this.cancel();
    }, (error) => {
        console.log(error);
        this.toastrService.error(error.error);
    });
   

  }
  public cancel() {
    this.cancelRegister.emit(false);
    console.log('cancelled');

  }
}