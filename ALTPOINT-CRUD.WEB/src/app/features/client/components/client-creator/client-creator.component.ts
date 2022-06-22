import { Component, OnInit } from '@angular/core';
import { Validators, FormBuilder } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ClientEvents } from '../../events/client.events';
import { Client } from '../../models/client.model';
import { ClientService } from '../../services/client.service';

@Component({
  selector: 'app-client-creator',
  templateUrl: './client-creator.component.html',
  styleUrls: ['./client-creator.component.scss']
})
export class ClientCreatorComponent implements OnInit {

  form = this.formBuilder.group({
    name: ['', [Validators.required]],
    surname: ['', [Validators.required]],
    patronymic: ['', [Validators.required]]
  });

  constructor(private clientService:ClientService,
    private dialogRef:MatDialogRef<ClientCreatorComponent>,
    private formBuilder:FormBuilder,
    private snackbar:MatSnackBar,
    private clientEvents:ClientEvents) { }

  ngOnInit(): void {
  }

  submit()
  {
    if (this.form.invalid)
    {
      return;
    }
    
    this.clientService.create(this.form.getRawValue() as Client)
      .subscribe(result => 
        {
          this.clientEvents.created$.next(result);
          this.dialogRef.close();
          this.snackbar.open('Клиент добавлен', undefined, { duration: 3000 });
        },
        error => 
        {
          this.snackbar.open('Произошла ошибка при добавлении клиента', undefined, { duration: 3000 });
        });
  }
}
