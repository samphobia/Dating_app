import { Injectable } from '@angular/core';
import { CanDeactivateFn } from '@angular/router';
import { MemberEditComponent } from '../members/member-edit/member-edit.component';

// @Injectable({
//   providedIn: 'root'
// })

export const preventUnsavedChangesGuard: CanDeactivateFn<MemberEditComponent> = (component: MemberEditComponent, currentRoute, currentState, nextState) => {
  if (component.editForm?.dirty) {
    return confirm('Are you sure you want to continue? Any unsaved changes will be lost');
  }
  return true;
};
