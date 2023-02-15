import { Component, Input, OnInit } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {MojConfig} from "../../moj-config";

@Component({
  selector: 'app-edit-student',
  templateUrl: './edit-student.component.html',
  styleUrls: ['./edit-student.component.css']
})
export class EditStudentComponent implements OnInit {

  studentOpstine: any;
  @Input() selectedStudent: any;

  constructor(private httpKlijent: HttpClient) { }

  getOpstine() :void
  {
    this.httpKlijent.get(MojConfig.adresa_servera+ "/Opstina/GetByAll", MojConfig.http_opcije()).subscribe(x=>{
      this.studentOpstine = x;
    });
  }

  saveChanges()
  {
    this.httpKlijent.post(MojConfig.adresa_servera+ "/Studenti/SaveChanges", this.selectedStudent, MojConfig.http_opcije()).subscribe(x=>{
      // TODO: Refresh student list
      // testirajWebApi();
    });
  }
  ngOnInit(): void {
    this.getOpstine();
  }

}
