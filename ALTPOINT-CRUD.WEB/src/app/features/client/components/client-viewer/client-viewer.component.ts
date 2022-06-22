import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ClientEvents } from '../../events/client.events';
import { Client } from '../../models/client.model';
import { ClientService } from '../../services/client.service';

@Component({
  selector: 'app-client-viewer',
  templateUrl: './client-viewer.component.html',
  styleUrls: ['./client-viewer.component.scss']
})
export class ClientViewerComponent implements OnInit {

  get isNewClient() : boolean
  {
    return this.client.id ? false : true;
  }

  get fullName() : string
  {
    return `${this.client.name} ${this.client.surname} ${this.client.patronymic}`
  }

  get modeMessage() : string
  {
    return this.editModeEnabled ? 'Редактирование' : 'Просмотр'
  }

  editModeEnabled:Boolean = false;
  form = this.formBuilder.group({
    id: ['', [Validators.required]],
    name: ['', [Validators.required]],
    surname: ['', [Validators.required]],
    patronymic: ['', [Validators.required]]
  });

  constructor(
    @Inject(MAT_DIALOG_DATA) public client: Client,
    private dialogRef:MatDialogRef<ClientViewerComponent>,
    private clientService:ClientService,
    private formBuilder:FormBuilder,
    private snackbar:MatSnackBar,
    private clientEvents:ClientEvents) { }

  ngOnInit(): void {
    this.form.patchValue(this.client)
  }

  editModeEnable()
  {
    this.editModeEnabled = true;
  }

  saveChanges()
  {
    this.editModeEnabled = false;
    this.clientService.update(this.form.getRawValue() as Client)
      .subscribe(result => 
        {
          this.client = result;
          this.form.patchValue(result);
          this.clientEvents.updated$.next(result);
          this.snackbar.open('Клиент обновлён', undefined, { duration: 3000 });
        },
        error => 
        {
          this.snackbar.open('Произошла ошибка при сохранении изменений', undefined, { duration: 3000 });
        });
  }

  delete()
  {
    this.clientService.delete(this.client)
      .subscribe(result => 
        {
          this.clientEvents.updated$.next(result);
          this.dialogRef.close();
          this.snackbar.open('Клиент удалён', undefined, { duration: 3000 });
        },
        error => 
        {
          this.snackbar.open('Произошла ошибка при удалении', undefined, { duration: 3000 });
        });
  }
}