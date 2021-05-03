import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

@NgModule({
  imports: [CommonModule, RouterModule, FormsModule, HttpClientModule],
  exports: [CommonModule, RouterModule, FormsModule, HttpClientModule],
})
export class SharedModule {}
