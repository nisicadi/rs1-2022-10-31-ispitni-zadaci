import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {MojConfig} from "../../moj-config";
import {HttpClient} from "@angular/common/http";

@Component({
  selector: 'app-edit-student',
  templateUrl: './edit-student.component.html',
  styleUrls: ['./edit-student.component.css']
})
export class EditStudentComponent implements OnInit {
  @Input() selectedStudent:any;
  @Input() studentAction:string;
  @Output() otvori = new EventEmitter<boolean>();
  showModal: boolean;
  opstine: any;

  constructor(private httpKlijent: HttpClient) { }

  ngOnInit(): void {
    this.getOpstine();
    this.showModal = true;
  }

  saveChanges() {
    this.httpKlijent.post(MojConfig.adresa_servera+ "/Student/SaveChanges", this.selectedStudent, MojConfig.http_opcije()).subscribe(x=>{
      this.closeModal();
    });
  }

  closeModal() {
    this.showModal = false;
    this.otvori.emit(this.showModal);
  }

  private getOpstine() {
    this.httpKlijent.get(MojConfig.adresa_servera+ "/Opstina/GetByAll", MojConfig.http_opcije()).subscribe(x=>{
      this.opstine = x;
    });
  }
}
